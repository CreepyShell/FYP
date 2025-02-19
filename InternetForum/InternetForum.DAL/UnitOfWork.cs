﻿using InternetForum.Administration.DAL.IdentityModels;
using InternetForum.DAL.Interfaces;
using InternetForum.DAL.Interfaces.RepositoryInterfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace InternetForum.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IPostRepository postRepository, IPostReactionRepository postReactionRepository, IUserRepository userRepository,
            ICommentRepository commentRepository, ICommentReactionRepository commentReactionRepository,
            UserManager<AuthUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            PostRepository = postRepository;
            UserRepostory = userRepository;
            CommentRepository = commentRepository;
            PostReactionRepository = postReactionRepository;
            CommentReactionRepository = commentReactionRepository;
            UserManager = userManager;
            RoleManager = roleManager;
        }
        public IPostRepository PostRepository { get; set; }
        public IUserRepository UserRepostory { get; set; }
        public ICommentRepository CommentRepository { get; set; }
        public IPostReactionRepository PostReactionRepository { get; set; }
        public ICommentReactionRepository CommentReactionRepository { get; set; }
        public UserManager<AuthUser> UserManager { get; set; }
        public RoleManager<IdentityRole> RoleManager { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                PostRepository.Dispose();
            }
        }

        public async Task<int> SaveChangesAsync()            
        {
            return await PostRepository.SaveChangesAsync();
        }
    }
}
