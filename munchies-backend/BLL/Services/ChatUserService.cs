using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ChatUserService
    {
        public static void setServerPassword(string oldPassword, string newPassword)
        {
            var prevPass = DataAccessFactory.serverPassData().Read(oldPassword);
            if (prevPass == null)
            {
                return;
            }
            DataAccessFactory.serverPassData().Delete(oldPassword);
            serverPass newPass = new serverPass();
            newPass.serverPassword = newPassword;
            DataAccessFactory.serverPassData().Create(newPass);
        }

        public static bool checkServerPassword(string password)
        {
            var pass = DataAccessFactory.serverPassData().Read(password);
            if (pass == null)
            {
                return false;
            }
            return true;
        }

        public static void setChatProfile(ChatProfileDTO chatProfile)
        {
            ChatUser chatUser = new ChatUser();
            chatUser.serial = chatProfile.Id.ToString();
            chatUser.username = chatProfile.username;
            chatUser.secret = chatProfile.secret;
            chatUser.email = chatProfile.email;
            chatUser.first_name = chatProfile.first_name;
            chatUser.last_name = chatProfile.last_name;
            DataAccessFactory.ChatUserData().Create(chatUser);
        }

        public static void deleteChatProfile(string id)
        {
            DataAccessFactory.ChatUserData().Delete(id);
        }

        public static List<ChatProfileDTO> getChatProfiles()
        {
            var chatUsers = DataAccessFactory.ChatUserData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ChatUser, ChatProfileDTO>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => int.Parse(src.serial)));
            });

            var mapper = cfg.CreateMapper();
            var mapped = mapper.Map<List<ChatProfileDTO>>(chatUsers);
            return mapped;
        }
    }
}
