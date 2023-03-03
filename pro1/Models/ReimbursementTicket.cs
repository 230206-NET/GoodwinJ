using Models.LengthException;
using Models.IntegerException;

namespace Models;

public class ReimbursementTicket
{
    public int Id {get; set; }
    public string Name {get; set; }
    private string _title = "";
    public string Title { 
        get
        {
            return _title;
        }
        set
        {
            if(value.Length >= 40)
            {
                throw new ArgumentLengthException("Title must be less than 40 characters");
            }
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Name cannot be empty");
            }
            _title = value;
        }
    }
    private string _amount = "";
    public string Amount {
        get
        {
            return _amount;
        } 
        set
        {
            int i = 0;
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Amount cannot be empty");
            }
            bool isNumber = int.TryParse(value, out i);
            if(!isNumber)
            {
                throw new ArgumentIntegerException("Amount must be integer");
            }
            _amount = value;
        }
    } 
    private string _description = "";
    public string Description {
        get
        {
            return _description;
        } 
        set
        {
            if(value.Length >= 200)
            {
                throw new ArgumentLengthException("Description must be less than 200 characters");
            }
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Description cannot be empty");
            }
            _description = value;
        } 
    }
    public string Status {get; set; }
}