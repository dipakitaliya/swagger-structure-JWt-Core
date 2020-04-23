# swagger-structure-JWt-Core

===========================How to creating Project===========================
- Create a new Asp.Net Core project. in this first create a empty solution. after, create a Class Library(.net Core) for Entity. after that,
  Create a class Library(.net Core) for Repository, Create a class Library(.net Core) for Contracts. after that, create a webapi project for api.
- Create a User class in Entity Library class.
- Create a Model class Context in Entity Library class.
- Set connectionstring in appsetting.
- Set up dbcontext in startup
- after that,added migrations.
- Create an interface for IRepositoryBase within the Contracts project.
- Create an Class for RepositoryBase within the Repository project.
- Create interface in the Contracts project for our  User class.
- Create a repository user classe in the Repository project.
- Create a new interface for IRepositoryWrapper in the Contract project.
- Ceate a new class for RepositoryWrapper in the Repository project
- In the Startup class in ConfigureServices method, set AddScoped.
- Create a new Acccount Controller and Set Connection to IWrapperRepository.
- after that,install the Swashbuckle for swagger api.
- In the Startup class in ConfigureServices method, set AddSwaggerGen.
- In the Startup class in Configure method, set UseSwagger and UseSwaggerUI.
- Create a user Register Method. and call the IWrapperRepository to register the action.
- In the Startup class in ConfigureServices method, set AddAuthentication service for add JwtBearer Token.
- In the Startup class in Configure method, set UseAuthentication.
- In the appsettings in set jwt key and secret.
- After That Create a login method. Unauthorized first responder. Then make the user an authorized user. Token generated from authorized user
  Generate token method is create when user authenticates. And have called it.
- a user list method has been create to retrieve the user list by passing this token into the authentication HTTP header.
- Token set to Postman. And get the user list.
- Create a user update and delete method and call it in IwrapperRepository.



========= Auth0 signup error =====================
- I faced this error in Auth0 Signup. " Auth0.Core.Exceptions.ErrorApiException: {"statusCode":401,"error":"Unauthorized","message":"Invalid token","attributes":{"error":"Invalid token"}} "
- I solved this error. This error occurs when creating an api in Auth0.
- When we use the default API "Auth0 Management API". When we go to "Test" TB within the API, the application itself becomes a new application called "Oth0 Management API (Test Application)".
My mistake was that I was using the "Auth0 Management API (Test Application)" API. Because of that I had to face this mistake.
Go to "Auth0 Management API" to fix this error. Then go to "API Explorer". There you will find "Token Expiration (seconds) *
Below that will be a "Save" button. Click it. Clicking on it will create a new application called "API Explorer App". Use it in the project. Your error will be corrected.
