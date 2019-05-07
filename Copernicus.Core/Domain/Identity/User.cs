using System;
using System.Text.RegularExpressions;
using Copernicus.Common.Types;

namespace Copernicus.Core.Domain.Identity
{
    public class User : IEntity
    {
        public const string EmailPattern =
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Name { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string ProviderName { get; protected set; }
        public string ProviderId { get; protected set; }
        public string AvatarUrl { get; protected set; }

        public string Role { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public User(Guid id,
            string email,
            string name,
            string firstName,
            string lastName,
            string role,
            string providerName,
            string providerId,
            string avatarUrl)
        {
            SetId(id);
            SetEmail(email);
            SetName(name);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetRole(role);
            SetProvider(providerName, providerId);
            SetAvatar(avatarUrl);
            CreatedAt = DateTime.UtcNow;
            Updated();
        }

        #region Setters

        public void SetId(Guid id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
                throw new DomainException("GUID is required.");

            Id = id;
            Updated();
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name is required.");

            Name = name;
            Updated();
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new DomainException("Email is required.");

            if (!new Regex(EmailPattern, RegexOptions.IgnoreCase).IsMatch(email))
                throw new DomainException("Email is invalid.");

            Email = email;
            Updated();
        }

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new DomainException("First name is required.");

            FirstName = firstName;
            Updated();
        }

        public void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new DomainException("Last name is required.");

            LastName = lastName;
            Updated();
        }

        public void SetProvider(string providerName, string providerId)
        {
            if (!Providers.IsValid(providerName))
                throw new DomainException("That provider isn't supported.");

            if (string.IsNullOrWhiteSpace(providerId))
                throw new DomainException("Provider identifier is required.");

            ProviderName = providerName;
            ProviderId = providerId;
            Updated();
        }

        public void SetAvatar(string avatarUrl)
        {
            AvatarUrl = avatarUrl;
        }

        public void SetRole(string role)
        {
            if (!Roles.IsValid(role))
                throw new DomainException("That role isn't exists.");

            Role = role;
            Updated();
        }


        public void Updated()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        #endregion

        public static User CreateFromFacebook(
            Guid id,
            FacebookUser facebookUser
        ) => new User(
            id,
            facebookUser.Email,
            facebookUser.Name,
            facebookUser.FirstName,
            facebookUser.LastName,
            Roles.User,
            Providers.Facebook,
            facebookUser.Id,
            facebookUser.Picture
        );
    }
}