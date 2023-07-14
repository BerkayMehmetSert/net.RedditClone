# Net Reddit Clone

This project is an example clone of the Reddit application built using the .NET framework. It aims to provide a
simplified version of the popular social news aggregation platform, Reddit. The project is intended to demonstrate the
use of various .NET technologies and best practices.

## Installing

1. Clone the repository

```
git clone https://github.com/BerkayMehmetSert/net.RedditClone.git
```

2. Install dependencies

```
dotnet restore
```

3. Create database

```
dotnet ef database update
```

4. Run the project

```
dotnet run
```

## Features

The Reddit clone includes the following features:

1. **User Registration and Authentication**: Users can create accounts and log in to the application.
2. **Subreddits**: Users can create and join different communities called subreddits, where they can post and interact
   with others.
3. **Posts**: Users can create text-based posts within a subreddit and view posts from other users.
4. **Comments**: Users can comment on posts and engage in discussions.
5. **Vote**: Users can upvote or downvote posts and comments, affecting their visibility and ranking.

## Technology Stack

The Reddit clone project utilizes the following technologies and frameworks:

- .NET Core: The project is built using the .NET Core framework, which provides a flexible and scalable platform for web
  application development.
- C#: The primary programming language used for the backend development of the application.
- Entity Framework Core: An ORM (Object-Relational Mapping) framework that simplifies database access and management.
- MSQL Server: The project uses MSQL Server as the relational database management system to store and retrieve
  application data.
