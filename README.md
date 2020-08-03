# Phoenix.WebApi
Project for Phoenix company. The project performs GitHub repositories search using GitHub API.


The project was developed on the server with .NET Framework(Web API) with Visual Studio Community 2019, on the client side with Angular 9 and Bootstrap CSS with Visual Studio Code, version 1.47.1.

To run the servers project you need open Phoenix.WebApi.sln - server side solution in the Visual Studio and start the project. On my computer the server was started with IIS Express with project URL: https://localhost:44372/. This way the server will be started.

To run clients side site open PhoenixGallery folder from the PhoenixGallery repository in the Visual Studio Code and execute npm install and ng serve commands. 
After the commands the clients side will be available with the URL http://localhost:4200/. In the environments\environment.ts file you can find the configuration for development. I used the configuration to define endpoints to connect to the server's service. If you change servers port it is need to change the clients side endpoint URL too.

export const environment = { production: false, apiEndpoint: 'https://localhost:44372/api', mvcEndPoint: 'https://localhost:44372/Home' };


Best regards !

