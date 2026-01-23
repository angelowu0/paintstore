Homework Submission Guide

Welcome!
This repository is the homework repository for the 10th .NET bootcamp.
To submit your homework correctly, follow the steps below exactly.

⚠️ Do NOT push directly to the parent repository.
All homework must be submitted via your own fork + Pull Request.

🧠 Overall Workflow (Important)

You will:

Fork the parent homework repository

Clone your fork to your local machine

Create a new branch for each homework

Commit your work to that branch

Create a Pull Request (PR)

Source: your homework branch

Destination: your forked main branch

1️⃣ Fork the Parent Repository

Open the parent homework repository

Click Fork (top-right corner)

Select your own GitHub account

✅ You now have your own copy of the homework repo.

2️⃣ Clone Your Fork to Your Computer

From your forked repository, copy the URL and run:

git clone https://github.com/YOUR_GITHUB_USERNAME/bootcamp-10th-homework-submission.git
cd bootcamp-10th-homework-submission

3️⃣ Create a New Branch for Your Homework

🚨 Never do homework on main

Create a new branch:

git checkout -b homework-week1


👉 Use clear names, for example:

homework-week1-csharp-basics

4️⃣ Do Your Homework

Complete the required files

Follow the instructions for the specific homework

Make sure your code runs successfully

Check changes:

git status

5️⃣ Commit Your Work
git add .
git commit -m "Complete Week 1 homework"


💡 Use meaningful commit messages.

6️⃣ Push Your Branch to Your Fork
git push origin homework-week1

7️⃣ Create a Pull Request (IMPORTANT)

Go to your forked repository on GitHub

Click Compare & pull request

Set:

Source branch: homework-week1

Destination branch: main (in your fork)

Add a clear title, for example:

Week 1 Homework Submission – John Smith


Click Create pull request

✅ This Pull Request is your homework submission

❌ Common Mistakes (Please Avoid)

🚫 Pushing directly to the parent repository
🚫 Doing homework on main
🚫 Creating PR to the parent repo instead of your fork
🚫 Submitting without commits
🚫 One branch for multiple homeworks

📝 Rules You Must Follow

One homework = one branch

One homework = one Pull Request

Do not modify other students’ folders

Late submissions may not be accepted/reviewed

Instructor feedback will be given inside the Pull Request

🆘 Need Help?

If you get stuck:

Check error messages carefully

Ask questions in the group chat / Discord

Include screenshots + error logs when asking for help

Happy coding 🚀
This workflow is exactly how real software teams work, so take it seriously 💪
