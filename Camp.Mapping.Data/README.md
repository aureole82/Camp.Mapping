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

(Optional) Extend custom user.
https://docs.microsoft.com/en-us/aspnet/core/security/authentication/add-user-data

1. Add extra property Name + Migration.
    ```c#
    [PersonalData]
    public string Name { get; set; }
    ```
2. Run the Identity scaffolder: Add → New Scaffolded Item... → Identity → Account\Manage\Index
3. Extend `\Areas\Identity\Pages\Account\Manage\Index.cshtml.cs` razor page and add an extra `<input>` to allow modifying the new field. Warning: Due to many issues of the templates you may (or may not) apply one or more modifications:
   * 2 submit buttons: https://github.com/aspnet/Scaffolding/issues/1014
   * No glyphicons and outdated bootstrap layout: https://github.com/aspnet/Scaffolding/issues/1015
   * Incomplete form on validation requests: https://github.com/aspnet/Scaffolding/issues/1016
