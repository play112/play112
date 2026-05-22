using Library.ApplicationCore.Enums;

public interface ILoanService
{
    Task<LoanReturnStatus> ReturnLoan(int loanId);
    Task<LoanExtensionStatus> ExtendLoan(int loanId);
    Task<LoanCreationStatus> CreateLoan(int bookItemId, int patronId);
    Task<List<dynamic>> GetAllLoans();
    Task<List<dynamic>> SearchLoans(string searchInput);
    Task<int> GetActiveLoansCount(int patronId);
}