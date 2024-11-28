using LeafyVersion3.Contracts.Requests;
using LeafyVersion3.Infrastructure.Model;
using LeafyVersion3.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


 
[ApiController]
[Route("api/auth")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public UserController(IUserRepository userRepository, JwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
    {
        if (await _userRepository.GetUserByEmailAsync(request.Email) != null)
        {
            return BadRequest("Email is already taken.");
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = hashedPassword
        };

        await _userRepository.CreateUserAsync(user);

        return Ok("User created successfully.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] SignInRequest request)
    {
        var user = await _userRepository.GetUserByUsernameAsync(request.Username!);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return Unauthorized("Invalid username or password.");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return Ok(new { Token = token });
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUser()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized("User ID not found in token.");
        }

        var user = await _userRepository.GetUserByIdAsync(Guid.Parse(userId)); 

        if (user == null)
        {
            return NotFound("User not found.");
        }

        return Ok(new
        {   
            user.Id,
            user.Username,
            user.Email,
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, UpdateUserRequest request)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);

        user.Username = request.Username;
        user.Email = request.Email;
        user.PasswordHash = hashedPassword;

        await _userRepository.UpdateUserAsync(user);

        return NoContent();
    }


    [HttpGet("all")]

    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetAllUsersAsync();

        var userList = users.Select(user => new
        {
            user.Id,
            user.Username,
            user.Email,
            Password = user.PasswordHash, 
        });

        return Ok(userList);
    }
}


