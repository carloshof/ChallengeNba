using Nba_Statistics.Data;
using System;
using System.Linq;


namespace Nba_Statistics.Services
{
    public class AuthenticationService 
    {
        private readonly Nba_StatisticsContext _context;

        public AuthenticationService(Nba_StatisticsContext context)
        {
            _context = context;
        }
        public bool isValid(string token)
        {
                return _context.Token.Any(auth =>
               auth.Key.Equals(token, StringComparison.OrdinalIgnoreCase)
               );
            
        }

       
            }
        }
    

