using sovmm_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sovmm_backend.Services
{
    public class UsersRepository
    {
        private static Global global = new Global();
        private readonly IMongoCollection<User> _mUsers;
        private readonly string _secretCredentials;
        public UsersRepository(IConnSettings connSettings)
        {
            var mongoClient = new MongoClient(connSettings.ConnUrl);
            var dB = mongoClient.GetDatabase(connSettings.DbName);
            _mUsers = dB.GetCollection<User>(connSettings.UserCollectionName);
            _secretCredentials = connSettings.SecretCredentials;

        }
        public List<User> LeerTodos()
        {
            return _mUsers.Find(elm => true).ToList();
        }

	public List<User> GetByACLVL(int accessLevel)
        {
            return _mUsers.Find(user => true).ToList();
        }


        public User Leer(string id)
        {
            return _mUsers.Find(elm => elm.Id == id).FirstOrDefault();
        }

        public User Crear(User user)
        {
            _mUsers.InsertOne(user);
            return user;
        }

        public void Actualizar(string id, User user)
        {
            _mUsers.ReplaceOne(elm => elm.Id == id, user);
        }

        public bool Borrar(string id)
        {
            _mUsers.DeleteOne(elm => elm.Id == id);
            return true;
        }

        public User GetByEmail(string email)
        {
            return _mUsers.Find(user => user.Email.ToLower().Contains(email.ToLower())).FirstOrDefault();
        }

        public User Login(AuthModel authModel)
        {
            var email = authModel.Email;
            var password = authModel.Password;
            var mobile = authModel.FromMobile;
            var user = _mUsers.Find(user => user.Email.ToLower() == email.ToLower()).FirstOrDefault();


            if (user == null)
            {
                User usr = new User();
                usr.Email = "ENF";
                return usr;
            }

            if (user.Password != password)
            {
                User usr = new User();
                usr.Password = "PNF";
                return usr;
            }

            var authHelper = new AuthHelper();
            var credentials = new UserCredentials();
            var expirationDays = 7;
            if (mobile)
            {
                expirationDays = 365;
            }
            credentials.Token = authHelper.GetJwtToken(user.Email, _secretCredentials, expirationDays);
            credentials.ExpirationInDays = expirationDays;
            user.Credentials = credentials;
            return user;
        }

    }
}
