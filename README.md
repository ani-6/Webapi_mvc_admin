# Webapi_mvc_Admin
Standalone webapi created in Visual Studio 2022 For Authentication and Authorization using jwt token

<h4>Create new role</h4> 
1. Start debuging </br>
2. open postman->body->raw (Format shoould be json) </br>
3. Method - POST 
    Url - https://localhost:44310/api/Roleapi/createrole  (Check your port once) </br>
4. For creating admin role put </br>
"Admin" </br>
5. Send </br></br>
6. Create "User" as well because its default registration role.

To check role created and users assgned to that role </br>
Method - GET 
Url - https://localhost:44310/api/Roleapi

<h4>To add additional info while registering user </h4>
1. Goto Models->IdentityModel.cs </br>
2. put your desired parameter in Class Applicationuser </br>
    eg  public string Name { get; set; } </br>
3. Perform migration with following commands </br>
<ul>
    <li>enable-migration</li>
    <li>add-migration Newmigration</li>
    <li>update-database</li>
</ul>
4. Add those parameter </br>
Models->AccountBindingModels.cs->Public Class RegisterBindingModel </br>
as well as </br>
Controller->Accountcontroller.cs->public async Task<IHttpActionResult> Register(RegisterBindingModel model) </br>

<h4>Register</h4>
1. Goto Postman </br>
2. Method - POST 
    Url - https://localhost:44310/api/Account/register </br>
3. select x-www-form-urlencode </br>
4. put all required values as key and value (username,name,email,password,confirmpassword) </br>
    eg  key - username value - admin </br>

To crate user as per various roles AccountController.cs->Register </br>
and change UserManager.AddToRole(user.Id, "User"): accordingly. </br>

<h4>Check Login</h4>
1. Goto Postman </br>
2. Method - POST 
    Url - https://localhost:44310/api/Account/login </br>
3. select x-www-form-urlencode </br>
4. put all required values as key and value </br>
    eg  key - username value - admin </br>
    key - password value - Pass@123 </br>
