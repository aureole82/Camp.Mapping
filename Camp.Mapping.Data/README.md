How to use ASP.NET Core Identity with custom user/role classes and custom primary key (e.g. `int`).
1. Install NuGet package "Microsoft.AspNetCore.Identity.EntityFrameworkCore"
(includes important Identity base classes and EntityFramework Core)
2. Implement custom user and role model and derive from `IdentityUser<T>` respectively `IdentityRole<T>` where `T` is your primary key (e.g. `UserModel : IdentityUser<int>` and `RoleModel : IdentityRole<int>`).
3. Inside web applications `Startup.cs`:
    * ~~.AddDefaultIdentity<IdentityUser>()~~
    * `.AddIdentity<UserModel, RoleModel>()`
    * `.AddDefaultTokenProviders()`
4. Find all old usages of `UserManager<IdentityUser>`, `SignInManager<IdentityUser>`, ... and change `IdentityUser` to the custom user.
5. Open Package Manager Console and add migration
    * `> Add-Migration Initial`
6. Install NuGet package "Microsoft.EntityFrameworkCore.SqlServer" (may be needed by the Migration / ModelSnapshot classes)