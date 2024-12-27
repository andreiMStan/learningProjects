using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WeblearnApi_Nihira.Helper;
using WeblearnApi_Nihira.Modal;
using WeblearnApi_Nihira.Repos;
using WeblearnApi_Nihira.Repos.Models;
using WeblearnApi_Nihira.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeblearnApi_Nihira.Container
{
 public class CustomerService : ICustomerService
 {
  private readonly LearndataContext _context;
  private readonly IMapper _mapper            ;
  private readonly ILogger<CustomerService> _logger;


  public CustomerService(LearndataContext context, IMapper mapper, ILogger<CustomerService> logger)
  {
   _context = context;
   _mapper = mapper;
   _logger = logger;
  }

  public async Task<APIResponse> Create(CustomerModal data)
  {
   APIResponse response = new APIResponse();
   try
   {
    _logger.LogInformation("Create Begins");
    TblCustomer _customer = _mapper.Map<CustomerModal, TblCustomer>(data);
    await _context.TblCustomers.AddAsync(_customer);
    await _context.SaveChangesAsync();
    response.ResponseCode = 201;
    response.Result=data.Code;
   }
   catch (Exception ex)
   {
    response.ResponseCode = 400;
    response.ErrorMessage = ex.Message;
    _logger.LogError(ex.Message,ex);
   }
   return response;
  }

  public async Task<List<CustomerModal>> GetAllAsync( )
  {
   List<CustomerModal> _response = new List<CustomerModal>();
   var _data =await _context.TblCustomers.ToListAsync();
   if (_data !=null)
   {
    _response = _mapper.Map<List<TblCustomer>, List<CustomerModal>>(_data);
   }
   return _response;
  }

  public async Task<CustomerModal> GetByCodeAsync(string code)
  {
   CustomerModal _response = new CustomerModal();
   var _data = await _context.TblCustomers.FindAsync(code);
   if (_data != null)
   {
    _response = _mapper.Map<TblCustomer,CustomerModal>(_data);
   }
   return _response;
  }

  public async Task<APIResponse> Remove(string code)
  {

   APIResponse response = new APIResponse();
   try
   {
    var _customer = await _context.TblCustomers.FindAsync(code);
    if (_customer!=null)
    {
     _context.TblCustomers.Remove(_customer);
     await _context.SaveChangesAsync();
    response.ResponseCode = 200;
    response.Result = code;
    }
    else
    {
     response.ResponseCode = 200;
     response.Result = code;
    }
   }

   catch (Exception ex)
   {
    response.ResponseCode = 404;
    response.ErrorMessage = "Data not found;";
    
   }
   return response;
  }

  public async Task<APIResponse> Update(CustomerModal data, string code)
  {


   APIResponse response = new APIResponse();
   try
   {
    var _customer = await _context.TblCustomers.FindAsync(code);
    if (_customer != null)
    {
     _customer.Name = data.Name;
     _customer.Email = data.Email;
     _customer.Phone = data.Phone;
     _customer.IsActive = data.IsActive;
     _customer.Creditlimit = data.Creditlimit;
     await _context.SaveChangesAsync();
     response.ResponseCode = 200;
     response.Result = code;
    }
    else
    {
     response.ResponseCode = 200;
     response.Result = code;
    }
   }

   catch (Exception ex)
   {
    response.ResponseCode = 404;
    response.ErrorMessage = "Data not found;";


   }
   return response;
  }
 }
}
