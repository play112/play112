using Library.ApplicationCore.Entities;

namespace Library.ApplicationCore;

public interface ILoanRepository {
    Task<Loan?> GetLoan(int loanId);
    Task<List<Loan>> GetAllLoans();
    Task<List<Loan>> SearchLoans(string searchInput);
    Task<List<Loan>> GetLoansByPatronId(int patronId);
    Task UpdateLoan(Loan loan);
    Task CreateLoan(Loan loan);
}