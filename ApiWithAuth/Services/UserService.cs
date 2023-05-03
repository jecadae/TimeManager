using ApiWithAuth.Domain;
using ApiWithAuth.DTOs;
using ApiWithAuth.Entity;
using ApiWithAuth.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace ApiWithAuth.Services;

public class UserService: IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly UsersContext _context;
    private readonly TokenService _tokenService;
    
    public UserService(UserManager<AppUser> userManager, UsersContext context, TokenService tokenService)
    {
        _userManager = userManager;
        _context = context;
        _tokenService = tokenService;
    }



    public async Task<AuthResponse> LoginAsync(AuthRequest request)
    {
                
        var managedUser = await _userManager.FindByEmailAsync(request.Email);
        
        if (managedUser == null)
            throw new BadHttpRequestException("Такой пользователь не был зарегестрирован",404);
        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);

        if (!isPasswordValid)
            throw new BadHttpRequestException("Неверный пароль",404);
        
        var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);
        if (userInDb is null)
            throw new UnauthorizedAccessException();
        
        var accessToken = _tokenService.CreateToken(userInDb);
        await _context.SaveChangesAsync();
        return (new AuthResponse
        {
            Email = userInDb.Email,
            Token = accessToken,
        });
    }


    public async Task<string> PasswordUpdateAsync(RefreshRequest request)
    {
                
        var managedUser = await _userManager.FindByEmailAsync(request.Email);
        
        if (managedUser == null)
            throw new BadHttpRequestException("Такой пользователь не был зарегестрирован",404);
        
        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);
        
        if (!isPasswordValid)
            throw new BadHttpRequestException("Неверный пароль",404);


        await _userManager.ChangePasswordAsync(managedUser,request.Password,request.NewPassword);
        
        var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);
        if (userInDb is null)
            throw new UnauthorizedAccessException();
        
        var accessToken = _tokenService.CreateToken(userInDb);
        await _context.SaveChangesAsync();
        
        return (accessToken);
    }

    public async Task RenameUserAsync(RenameRequest request)
    {
        var userInDb = await _userManager.FindByEmailAsync(request.Email);
        if (userInDb is null)
            throw new BadHttpRequestException("Такой пользователь не был зарегестрирован",404);
        
        userInDb.FirstName = request.FirstName;
        userInDb.Patronymic = request.Patronymic;
        userInDb.LastName = request.LastName;
        await _context.SaveChangesAsync();
    }

    public async Task<AppUser?> GetUserByEmail(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<List<AppUser>> GetAllUsers()
    {
        return await _userManager.Users.AsNoTracking().ToListAsync();
    }


    public async Task ForgotPasswordAsync(string email)
    {
        var userInDb = await _userManager.FindByEmailAsync(email);
        if (userInDb is null)
            throw new BadHttpRequestException("Такой пользователь не был зарегестрирован",404);

        string resetToken = await _userManager.GeneratePasswordResetTokenAsync(userInDb);
        MimeMessage message = new MimeMessage();
        message.From.Add(new MailboxAddress("Testes","dgmix999@gmail.com"));
        message.To.Add(MailboxAddress.Parse("dgmix999@gmail.com"));
        message.Subject = "работай пжпжп";
        message.Body = new TextPart("plain")
        {
            Text = @"sdadsadsdsadsasd"
        };
        SmtpClient client = new SmtpClient();
        try
        {
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("dgmix999@gmail.com","Lfybbk2002");
            client.Send(message);
            Console.WriteLine(resetToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            client.Disconnect(true);
            client.Dispose();
        }

        
        
    }

}