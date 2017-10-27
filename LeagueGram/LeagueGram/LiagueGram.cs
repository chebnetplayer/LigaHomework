using System;
using System.Linq;

namespace LeagueGram
{
    public static class LiagueGram
    {
        public static User User { get; private set; }

        public static Guid Registrate(string nickname)
        {
            ChatRep.Registrate(nickname);
            return ChatRep.Users[ChatRep.Users.Length - 1].Id;
        }
        public static void LogIn(Guid userid)
        {
            var user = ChatRep.LogIn(userid);
            User = user;
        }
        public static Guid CreatePrivate(string chatname, Guid inviteUser)
        {
            ChatRep.CreatePrivate(chatname, User.Id, inviteUser);
            return ChatRep.Chats[ChatRep.Chats.Length - 1].Id;
        }
        public static Guid CreateChannel(string chatname, Guid host)
        {
            ChatRep.CreateChannel(chatname, User.Id);
            return ChatRep.Chats[ChatRep.Chats.Length - 1].Id;
        }
        public static Guid CreateGroup(string chatname, Guid[] inviteUsers)
        {
            ChatRep.CreateGroup(chatname, User.Id, inviteUsers);
            return ChatRep.Chats[ChatRep.Chats.Length - 1].Id;
        }

        public static Guid SendMessage(string text,Guid chatid)
        {
            var chatType = ChatRep.GetChat(chatid).ChatType;
            switch (chatType)
            {
                case ChatType.Channel:
                {
                    var chat = (Channel) ChatRep.GetChat(chatid);
                    chat.SendMessage(User.Id, text);
                    return chat.Messages[chat.Messages.Length - 1].Id;
                }
                case ChatType.Group:
                {
                    var chat = (Group) ChatRep.GetChat(chatid);
                    chat.SendMessage(User.Id, text);
                    return chat.Messages[chat.Messages.Length - 1].Id;
                    }
                case ChatType.PrivateChat:
                {
                    var chat = (PrivateChat) ChatRep.GetChat(chatid);
                    chat.SendMessage(User.Id, text);
                    return chat.Messages[chat.Messages.Length - 1].Id;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static void EditMessage(string newtext, Guid chatId,Guid messageId)
        {
            ChatRep.GetChat(chatId).EditMessage(messageId, newtext, User.Id);
        }

        public static void DeleteMessege(Guid chatid, Guid messageid)
        {
            ChatRep.GetChat(chatid).DeleteMessege(messageid, User.Id);
        }

        public static void InviteUser(Guid chatid, Guid targetuserId)
        {
            var chatType = ChatRep.GetChat(chatid).ChatType;
            var targetuser = ChatRep.Users.First(i => i.Id == targetuserId);
            switch (chatType)
            {
                case ChatType.Channel:
                {
                    var chat = (Channel)ChatRep.GetChat(chatid);
                        chat.InviteUser(targetuser, User.Id);
                    break;
                }
                case ChatType.Group:
                {
                    var chat = (Group)ChatRep.GetChat(chatid);
                    chat.InviteUser(targetuser, User.Id);
                        break;
                }
                case ChatType.PrivateChat:
                {
                    var chat = (PrivateChat)ChatRep.GetChat(chatid);
                    chat.InviteUser(targetuser, User.Id);
                        break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public static void PromoteMemberToAdmin(Guid chatid, Guid targetMemberId)
        {
            ChatRep.GetChat(chatid).PromoteMemberToAdmin(targetMemberId, User.Id);
        }

        public static void DeleteMemberFromAdmin(Guid targetMemberId, Guid chatid)
        {
            ChatRep.GetChat(chatid).DeleteMemberFromAdmin(targetMemberId,User.Id);
        }
        
    }
}
