using AutoMapper;
using Manager.Services.Interfaces;


namespace Manager.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.Email);

            if (userExists != null)
            {
                throw new DomainException("Já existe um usuario cadastrado com email informado");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userDTO);

        }
        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _userRepository.Get(userDTO);

            if (userExists != null)
            {
                throw new DomainException("Não existe nenhum usuario com o id informado");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userUpdated = await _userRepository.Update(user);

        }
        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
        }
        public async Task<UserDTO> Get(long id)
        {
            var allUsers = await _userRepository.Get();

            return _mapper.Map<List<UserDTO>>(allUsers);

        }
        public async Task<List<UserDTO>> Get()
        {
            var user = await _userRepository.Get(id);

            return _mapper.Map<List<UserDTO>>(user);

        }
        public async Task<List<UserDTO>> SearchByName(string name)
        {
            var allUsers = await _userRepository.SearchByName();

            return _mapper.Map<List<UserDTO>>(allUsers);

        }
        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var allUsers = await _userRepository.SearchByEmail(email);

            return _mapper.Map<List<UserDTO>>(allUsers);
        }



        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            return _mapper.Map<UserDTO>(user);
        }

    }

}