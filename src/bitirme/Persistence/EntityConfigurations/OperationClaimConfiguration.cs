using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Students.Constants;
using Application.Features.Lecturers.Constants;
using Application.Features.Messages.Constants;
using Application.Features.FirstInternships.Constants;
using Application.Features.Notifications.Constants;
using Application.Features.SecondInternships.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Students CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StudentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Read },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Write },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Create },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Update },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Lecturers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LecturersOperationClaims.Admin },
                new() { Id = ++lastId, Name = LecturersOperationClaims.Read },
                new() { Id = ++lastId, Name = LecturersOperationClaims.Write },
                new() { Id = ++lastId, Name = LecturersOperationClaims.Create },
                new() { Id = ++lastId, Name = LecturersOperationClaims.Update },
                new() { Id = ++lastId, Name = LecturersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Lecturers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LecturersOperationClaims.Admin },
                new() { Id = ++lastId, Name = LecturersOperationClaims.Read },
                new() { Id = ++lastId, Name = LecturersOperationClaims.Write },
                new() { Id = ++lastId, Name = LecturersOperationClaims.Create },
                new() { Id = ++lastId, Name = LecturersOperationClaims.Update },
                new() { Id = ++lastId, Name = LecturersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        
        #region Messages CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MessagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Read },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Write },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Create },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Update },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region FirstInternships CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = FirstInternshipsOperationClaims.Admin },
                new() { Id = ++lastId, Name = FirstInternshipsOperationClaims.Read },
                new() { Id = ++lastId, Name = FirstInternshipsOperationClaims.Write },
                new() { Id = ++lastId, Name = FirstInternshipsOperationClaims.Create },
                new() { Id = ++lastId, Name = FirstInternshipsOperationClaims.Update },
                new() { Id = ++lastId, Name = FirstInternshipsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Lecturers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LecturersOperationClaims.Admin },
                new() { Id = ++lastId, Name = LecturersOperationClaims.Read },
                new() { Id = ++lastId, Name = LecturersOperationClaims.Write },
                new() { Id = ++lastId, Name = LecturersOperationClaims.Create },
                new() { Id = ++lastId, Name = LecturersOperationClaims.Update },
                new() { Id = ++lastId, Name = LecturersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Messages CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MessagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Read },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Write },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Create },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Update },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Notifications CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Read },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Write },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Create },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Update },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SecondInternships CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SecondInternshipsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SecondInternshipsOperationClaims.Read },
                new() { Id = ++lastId, Name = SecondInternshipsOperationClaims.Write },
                new() { Id = ++lastId, Name = SecondInternshipsOperationClaims.Create },
                new() { Id = ++lastId, Name = SecondInternshipsOperationClaims.Update },
                new() { Id = ++lastId, Name = SecondInternshipsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Students CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StudentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Read },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Write },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Create },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Update },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region FirstInternships CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = FirstInternshipsOperationClaims.Admin },
                new() { Id = ++lastId, Name = FirstInternshipsOperationClaims.Read },
                new() { Id = ++lastId, Name = FirstInternshipsOperationClaims.Write },
                new() { Id = ++lastId, Name = FirstInternshipsOperationClaims.Create },
                new() { Id = ++lastId, Name = FirstInternshipsOperationClaims.Update },
                new() { Id = ++lastId, Name = FirstInternshipsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SecondInternships CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SecondInternshipsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SecondInternshipsOperationClaims.Read },
                new() { Id = ++lastId, Name = SecondInternshipsOperationClaims.Write },
                new() { Id = ++lastId, Name = SecondInternshipsOperationClaims.Create },
                new() { Id = ++lastId, Name = SecondInternshipsOperationClaims.Update },
                new() { Id = ++lastId, Name = SecondInternshipsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Students CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StudentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Read },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Write },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Create },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Update },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Students CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StudentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Read },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Write },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Create },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Update },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Students CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StudentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Read },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Write },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Create },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Update },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Messages CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MessagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Read },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Write },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Create },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Update },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Messages CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MessagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Read },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Write },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Create },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Update },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Messages CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MessagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Read },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Write },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Create },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Update },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Notifications CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Read },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Write },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Create },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Update },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
