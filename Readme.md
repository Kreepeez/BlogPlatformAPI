**Introduction**
This application is a backend solution for a simple blogging platform in asp.net core. It uses a custom REST API for all requests. It can be used to create, read, update and delete blog posts as well as filter blog posts by tag and list all tags in the system.

- Please note that API uses slugs instead of IDs
- Slugs are used to identify blog posts in a way that is more URL friendly than IDs
- They are generated from the title of the blog post

**Route**
*localhost:port/api/posts*  -for blog posts.
*localhost:port/api/tags*  -for a list of tags.
*localhost:port/api/posts?tag=exampletag*  -for filtering posts by tag

**Instructions:**

 - Connect to your database.
 - Type your connection string in the appsettings.json file.
 - Enable migrations in the console.
 - Add an initial migration in the console.
 - Send GET, POST, PUT, DELETE requests. You can use Postman to test.


