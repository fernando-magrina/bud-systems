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

<img width="940" height="414" alt="image" src="https://github.com/user-attachments/assets/6c266d4b-121d-4493-92fb-02fbd237b133" />

 • The .spec files included in the Visual Studio Angular template were not working, so I replaced them with simple .test.ts files that run using npm test. This kept the client-side tests working without needing to fix the template.​ Please use the Developer PowerShell in Visual Studio to run those tests.

<img width="940" height="425" alt="image" src="https://github.com/user-attachments/assets/5f052b24-6304-4f66-9de3-d3a5ff1fa8d1" />

 • When you clone the repo, some versions of Visual Studio show a fake fullbench-dll.sln entry in Solution Explorer. It does not exist on disk and cannot be removed. Please ignore it.​

<img width="628" height="367" alt="image" src="https://github.com/user-attachments/assets/5e76e0f6-639e-4989-afde-b3c5d8f380a7" />

• Because the requirements did not include update or delete operations, I did not pass IDs or extra fields to the front end.
• For validation and mapping, I was unsure whether to use external packages, since the project is very small. I decided to keep validation as simple code. For mapping, I used AutoMapper to demonstrate something different.
