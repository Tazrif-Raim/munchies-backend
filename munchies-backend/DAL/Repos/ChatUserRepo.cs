using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ChatUserRepo : Repo, IRepo<ChatUser, string, ChatUser>
    {
        public ChatUser Create(ChatUser obj)
        {
            db.ChatUsers.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            db.ChatUsers.Remove(ex);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<ChatUser> Read()
        {
            return db.ChatUsers.ToList();
        }

        public ChatUser Read(string id)
        {
            return db.ChatUsers.Find(id);
        }

        public ChatUser Update(ChatUser obj)
        {
            var ex = Read(obj.serial);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
