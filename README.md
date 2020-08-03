# Phoenix.WebApi
Project for Phoenix company. The project performs GitHub repositories search using GitHub API.


The projectwas developed on the server with .NET Framework(Web API) with Visual Studio Community 2019, on the client side with Angular 9 and Bootstrap CSS with Visual Studio Code, version 1.47.1.

To run the the servers project you need open Phoenix.WebApi.sln - server side solution in the Visual Studio and start the project. On my computer the server was started with IIS Express with project URL: https://localhost:44372/. This way the server will be started.

To run clients side site open PhoenixGallery folder in the Visual Studio Code and execute npm install and ng serve commands. After the commands the clients side will be available with the URL http://localhost:4200/. In the environments\environment.ts file you can find the configuration for development. I used the configuration to define endpoints to connect to the server's service. If you change servers port it is need to change the clients side endpoint URL too.

export const environment = { production: false, apiEndpoint: 'https://localhost:44372/api', mvcEndPoint: 'https://localhost:44372/Home' };


I developed the project but I did not use ASP.NET Session to store bookmarked repository items. I tried to achieve it with the classes 
SessionableControllerHandler and SessionStateRouteHandler, but Session was different for subsequent requests from the Angular client.
Instead of Session I used GitHubItems.json file to save bookmarked of repository items.
  
I have read about using of Session with WEB.API on the stackoverflow site:
REST by design is stateless. By adding session (or anything else of that kind) you are making it stateful and defeating any purpose of having a RESTful API.

