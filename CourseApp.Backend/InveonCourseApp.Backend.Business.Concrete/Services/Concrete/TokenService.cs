namespace InveonCourseApp.Backend.Business.Concrete.Services.Concrete
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly Core.Options.TokenOptions tokenOptions;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        public TokenService(UserManager<IdentityUser> userManager, IOptions<Core.Options.TokenOptions> tokenOptions, IStringLocalizer<MessageResources> stringLocalizer)
        {
            this.userManager = userManager;
            this.tokenOptions = tokenOptions.Value;
            this.stringLocalizer = stringLocalizer;
        }

        private async Task<IEnumerable<Claim>> GenerateIdentityUserClaimsAsync(IdentityUser identityUser, AuditablePersonBaseEntityDto auditablePersonBaseEntityDto)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, identityUser.Id!),
                new Claim(JwtRegisteredClaimNames.GivenName, $"{auditablePersonBaseEntityDto.Name}"),
                new Claim(JwtRegisteredClaimNames.FamilyName, $"{auditablePersonBaseEntityDto.Surname}"),
                new Claim(JwtRegisteredClaimNames.Email, auditablePersonBaseEntityDto.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, identityUser.UserName!),
                //new Claim(JwtRegisteredClaimNames.Sub, identityUser.UserName!),
                //new Claim("uid", identityUser.Id)
            };

            var identityUserRoles = await userManager.GetRolesAsync(identityUser);
            if (identityUserRoles is null) return null;

            claims.AddRange(identityUserRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            return claims;
        }

        public async Task<IDataResult<TokenDto>> CreateAccessTokenAsync(IdentityUser identityUser, AuditablePersonBaseEntityDto auditablePersonBaseEntityDto)
        {
            var issuerSigningSymmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.IssuerSigningSymmetricSecurityKey));
            if (issuerSigningSymmetricSecurityKey is null) return new ErrorDataResult<TokenDto>(stringLocalizer[Message.Token_Could_Not_Generated]);

            var signingCredentials = new SigningCredentials(issuerSigningSymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            if (signingCredentials is null) return new ErrorDataResult<TokenDto>(stringLocalizer[Message.Token_Could_Not_Generated]);

            var claims = await GenerateIdentityUserClaimsAsync(identityUser, auditablePersonBaseEntityDto);
            if (claims is null) return new ErrorDataResult<TokenDto>(stringLocalizer[Message.Token_Could_Not_Generated]);

            var jwtSecurityToken = new JwtSecurityToken(
                audience: tokenOptions.Audience,
                issuer: tokenOptions.Issuer,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddDays(tokenOptions.Expiration),
                notBefore: DateTime.UtcNow,
                claims: claims
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            if (accessToken is null) return new ErrorDataResult<TokenDto>(stringLocalizer[Message.Token_Could_Not_Generated]);

            return new SuccessDataResult<TokenDto>(new TokenDto { AccessToken = accessToken, Expiration = jwtSecurityToken.ValidTo }, stringLocalizer[Message.Token_Was_Generated_Successfully]);
        }
    }
}