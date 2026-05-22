using Library.ApplicationCore.Enums;

public interface IPatronService
{
    Task<MembershipRenewalStatus> RenewMembership(int patronId);
    Task<List<dynamic>> GetAllPatrons();
    Task<List<dynamic>> SearchPatrons(string searchInput);
}
