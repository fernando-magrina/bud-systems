# Country Info App

Angular: 20.3.15
Package Version
@angular-devkit/architect 0.2003.13
@angular-devkit/core 20.3.13
@angular-devkit/schematics 20.3.13
@angular/build 20.3.13
@angular/cli 20.3.13
@schematics/angular 20.3.13
rxjs 7.8.2
typescript 5.8.3
zone.js 0.15.1
Node.js v22.12.0

• I used Visual Studio INSIDERS for this project.
• I added a Startup Profile so both the client and the server run when you press Start in Visual Studio.​

![alt text](image.png)

 • The .spec files included in the Visual Studio Angular template were not working, so I replaced them with simple .test.ts files that run using npm test. This kept the client-side tests working without needing to fix the template.​ Please use the Developer PowerShell in Visual Studio to run those tests.

![alt text](image-1.png)

 • When you clone the repo, some versions of Visual Studio show a fake fullbench-dll.sln entry in Solution Explorer. It does not exist on disk and cannot be removed. Please ignore it.​

![alt text](image-2.png)

• Because the requirements did not include update or delete operations, I did not pass IDs or extra fields to the front end.
• For validation and mapping, I was unsure whether to use external packages, since the project is very small. I decided to keep validation as simple code. For mapping, I used AutoMapper to demonstrate something different.