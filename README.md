# Task Management Application

## 📖 Overview
This is a **C#-based task management application** designed to manage tasks efficiently. The backend is built with **ASP.NET Core**, and the frontend is implemented using **React with Tailwind CSS**.

## 🛠️ Tech Stack
- **Backend**: C# (.NET 8), ASP.NET Core, RESTful APIs, Visual Studio 2022
- **Frontend**: React.js, Tailwind CSS
- **Cloud & DevOps**: Docker, AWS/GCP (if applicable)

---

## 🚀 Getting Started  

### 1️ **Prerequisites**
Ensure you have the following installed on your machine:
- [.NET SDK (8.0+)](https://dotnet.microsoft.com/en-us/download)
- [Git](https://git-scm.com/)
- [Docker](https://www.docker.com/)
- [AWS CLI](https://aws.amazon.com/cli/)

---

### 2️ **Setting Up the Backend**
1. Clone the repository:  
   git clone https://github.com/then0310/task_management_backend.git

2. Open the project:
   Navigate to the project directory and open it using Visual Studio 2022.

3. Ensure dependencies are installed:
   Verify that Microsoft.AspNetCore.Cors is installed via NuGet Package Manager.

4. Run the project:
   Use IIS Express to launch the application.

### 3 **Deploy to AWS ECS**
1. Navigate to the project directory
   cd your-repo-name

2. Set up AWS credentials by running aws configure as below
   AWS Access Key ID [None]: Your AWS Access Key
   AWS Secret Access Key [None]: Your AWS Secret Access Key
   Default region name [None]:ap-southeast-1
   Default output format [None]: 

3. Check if the AWS credentials are configured correctly by opening the file. For Windows, it will be in C:\Users\USERNAME\.aws\credentials. For macOS and Linux, it should be in ~/.aws/credentials. (Optional)

4. Then run below command to assume role for AWS, use the related information in parameters: 
   aws sts assume-role --role-arn arn:aws:iam::<AWS Account ID>:role/<AWS IAM Role> --role-session-name "<Session Name>" --region <AWS region>

5. Copy the variables of AccessKeyId, SecretAccessKey, and SessionToken from current session, then set in current environment variable as 
   SET AWS_ACCESS_KEY_ID= xxx
   SET AWS_SECRET_ACCESS_KEY= xxx
   SET AWS_SESSION_TOKEN= xxx 

6. In the terminal, go to the directory containing the repository you wish to deploy, and checkout the branch you wish to use. Run docker command as below with space and dot
   docker build -t <Docker Repository Name>:<tag> .

7. Once it is done, check if your docker image exists by running `docker images`. Note the IMAGE ID

8. Need to create Private repositories in AWS ECR for first time

9. Tag the docker image so that it can be pushed to ECR by running
   docker tag <IMAGE ID> <AWS ECR URI>:latest

10. Push to ECR by running below 2 commands
   aws ecr get-login-password --region <AWS region> | docker login --username AWS --password-stdin <AWS ECR URI>
   docker push <AWS ECR URI>:latest

11. Log in to AWS Console and open Elastic Container Registry (ECR)

12. Check if your image was pushed successfully by checking the Pushed at column 

13. Create task definitions if setting up for the first time. If task definitions already exist, update the Image URI in the container and click Create.

14. If setting up for the first time, create the cluster and services in AWS ECS. If they already exist, click Update service in the top right corner, check Force new deployment, select the latest revision, then scroll down and click Update.

15. Ensure that the task status is Running, and the previous task will be gradually terminated.
	
	


