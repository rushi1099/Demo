using Demo.Models;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Title = "Home Page";

            return View();
        }
        //[HttpPost]
        //public ActionResult GetList()
        //{
        //    List<MyModel> data = MyModel.GetData();
        //    return View("Index", data);
        //}

        [HttpPost]
        public ActionResult Load()
        {
            // Load the data and pass it to the view
            List<MyModel> books = MyModel.GetData();
            return View("Index", books);
        }

        [HttpPost]
        public ActionResult AddToShoppingCart(int bookId)
        {
            // Logic to add the book to the shopping cart
            // For now, you can just simulate with a TempData message
            TempData["Message"] = $"Book with ID {bookId} added to the cart.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Commit()
        {
            // Logic to commit the changes
            TempData["Message"] = "Changes have been committed.";
            return RedirectToAction("Index");
        }
        public void OnPostCommit()
        {
            string repoPath = Directory.GetCurrentDirectory(); // Path to your local Git repository
            string remoteName = "startup"; // The name of the remote repository
            string branchName = "main"; // The branch you want to push to
            string username = "RD-FD"; // Your remote repository username
            string password = "needWork@12"; // Your remote repository password

            try
            {
                PushChanges(repoPath, remoteName, branchName, username, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PushChanges(string repoPath, string remoteName, string branchName, string username, string password)
        {
            try
            {
                // Open the repository
                using (var repo = new Repository(repoPath))
                {
                    // Create credentials for authentication
                    var credentials = new UsernamePasswordCredentials
                    {
                        Username = username,
                        Password = password
                    };

                    // Find the remote
                    var remote = repo.Network.Remotes[remoteName];
                    if (remote == null)
                    {
                        Console.WriteLine($"Remote '{remoteName}' not found.");
                        return;
                    }

                    // Create a push options object
                    var pushOptions = new PushOptions
                    {
                        CredentialsProvider = (url, user, cred) => credentials
                    };

                    // Get the reference to the branch
                    var branch = repo.Branches[branchName];
                    if (branch == null)
                    {
                        Console.WriteLine($"Branch '{branchName}' not found.");
                        return;
                    }

                    // Push the branch to the remote
                    repo.Network.Push(branch, pushOptions); //repo.Network.Push(branch, pushOptions);
                    // if (result.Status == PushStatus.UpToDate)
                    // {
                    //     Console.WriteLine("Push was successful.");
                    // }
                    // else
                    // {
                    //     Console.WriteLine("Push was not successful.");
                    // }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
