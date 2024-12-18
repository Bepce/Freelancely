namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtention
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
