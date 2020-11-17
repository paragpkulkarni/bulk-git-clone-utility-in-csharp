Purpose of this utiltiy is to automate git clone command. It is helpful when you want to clone multiple git repositories on multiple machines. This utility will automate git clone process. 

**Required inputs**
1. List of git/github URL's should be assigned to gitRepoURLList variable in Porgram.cs. Currenlty URL's are  hard coded in the system. Feel free to replace with your own URL's	
2. Path on the machine where you want clone the repository. Replace the value of gitClonePath variable in Program.cs to match the path in your system.

**Limitations**

	It does not support authetntication for the git.
