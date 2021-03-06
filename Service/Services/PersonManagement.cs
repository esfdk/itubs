﻿namespace BookITService.Services
{
    using System.Collections.Generic;

    using BookITService.Entities;
    using BookITService.Enums;
    using BookITService.Interfaces;


    public partial class Service : IPersonManagement
    {
        /// <summary>
        /// Attempt to login a user.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="person">The person object in which to fill in data.</param>
        /// <returns>The status of the login request.</returns>
        public LoginStatus Login(string username, string password, out Person person)
        {
            person = null;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return LoginStatus.InvalidInput;
            }

            var p = Person.Login(username, password);

            if (p == null)
            {
                return LoginStatus.WrongUserNameOrPassword;
            }

            if (string.IsNullOrWhiteSpace(p.Token))
            {
                return LoginStatus.InvalidInput;
            }

            if (p.ID == -1)
            {
                return LoginStatus.CommunicationFailure;
            }

            person = p;
            return LoginStatus.Success;
        }

        public RequestStatus Logout(string token)
        {
            return !string.IsNullOrWhiteSpace(token) ? Person.Logout(token) : RequestStatus.InvalidInput;
        }

        public RequestStatus GetAllOfUsers(string token, out IEnumerable<Person> people)
        {
            people = null;

            if (string.IsNullOrWhiteSpace(token))
            {
                return RequestStatus.InvalidInput;
            }

            people = Person.All;

            return RequestStatus.Success;
        }

        public RequestStatus GetByEmail(string token, ref Person person)
        {
            if (string.IsNullOrWhiteSpace(token) || person == null || string.IsNullOrWhiteSpace(person.Email))
            {
                return RequestStatus.InvalidInput;
            }

            person = Person.GetByEMail(person.Email);

            if (person == null)
            {
                return RequestStatus.InvalidInput;
            }

            person.Token = null;
            return RequestStatus.Success;
        }

        public RequestStatus GetByToken(string token, out Person person)
        {
            person = null;

            if (string.IsNullOrWhiteSpace(token))
            {
                return RequestStatus.InvalidInput;
            }

            person = Person.GetByToken(token);

            return person == null ? RequestStatus.InvalidInput : RequestStatus.Success;
        }
    }
}