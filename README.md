# Webapi_mvc_Admin
Standalone webapi created in Visual Studio 2022 For Authentication and Authorization using jwt token

To create new role start debuging, goto postman->body->raw (Format shoould be json)
Method - POST 
Url - https://localhost:44310/api/Roleapi/createrole  (Check your port once)
for creating admin role put
"Admin" 
and click send

To check role created and users assgned to that role 
Method - GET 
https://localhost:44310/api/Roleapi

To add additional info while signing up goto 
Models->IdentityModel.cs 
put your desired parameter in Class Applicationuser
eg  public string Name { get; set; }
and perform migration
1. enable-migration
2. add-migration Newmigration
3. update-database

Add those parameter 
Models->AccountBindingModels.cs->Public Class RegisterBindingModel

Controller->Accountcontroller.cs->public async Task<IHttpActionResult> Register(RegisterBindingModel model)

<h4>Register</h4>
Goto Postman
Method - POST 
Url - https://localhost:44310/api/Account/register
select x-www-form-urlencode
put all required values as key and value
eg  key - username value - admin

To crate user as per various roles AccountController.cs->Register
and change UserManager.AddToRole(user.Id, "User"): accordingly.

<h4>Check Login</h4>
Goto Postman
Method - POST 
Url - https://localhost:44310/api/Account/login
select x-www-form-urlencode
put all required values as key and value
eg  key - username value - admin
    key - password value - Pass@123
