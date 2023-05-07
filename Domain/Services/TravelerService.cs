using AutoMapper;
using Domain.Contracts;
using Domain.Contracts.Services;
using Domain.Entities.Mongo;
using Domain.Exceptions;
using Domain.Models.Traveler;
using Domain.Models.Whatsapp;

namespace Domain.Services
{
    public class TravelerService : ITravelerService
    {
        private readonly IRepository<TravelerEntity> _travelerRepository;
        private readonly IMapper _mapper;
        private readonly IWhatsappService _whatsappService;

        public TravelerService(IRepository<TravelerEntity> travelerRepository, IMapper mapper, IWhatsappService whatsappService)
        {
            _travelerRepository = travelerRepository;
            _mapper = mapper;
            _whatsappService = whatsappService;
        }


        public async Task<TravelerEntity> GetById(string id)
        {
            var travelerEntity = await _travelerRepository.FindOneAsync(x => x.Id.ToString().Equals(id));

            if (travelerEntity == null)
                throw new DomainNotFoundException("Dados do Viajante não encontrado.");

            return travelerEntity;
        }

        public async Task<IEnumerable<TravelerEntity>> GetAll()
        {
            return await _travelerRepository.FindAsync(x => x.IsActive);
        }

        public async Task<TravelerResponseModel> Create(TravelerRequestModel travelerRequestModel)
        {
            var travelerEntity = new TravelerEntity
            {
                Name = travelerRequestModel.Name,
                Email = travelerRequestModel.Email,
                CPF = travelerRequestModel.CPF,
                Telephone = travelerRequestModel.Telephone,
                Accessibility = travelerRequestModel.Accessibility,
                HotelName = travelerRequestModel.HotelName,
                CheckIn = travelerRequestModel.CheckIn,
                CheckOut = travelerRequestModel.CheckOut,
                ReservationId = travelerRequestModel.ReservationId,
                RoomType =  travelerRequestModel.RoomType,
                CancelData = travelerRequestModel.CancelData,
                RoomNumber = travelerRequestModel.RoomNumber,
                IsActive = true
            };

            var createdId = await _travelerRepository.InsertOneAsync(travelerEntity);
            var response = new TravelerResponseModel
            {
                Id = createdId.ToString()
            };

            return response;
        }

        public async Task Update(TravelerEntity travelerEntity, bool sendConfirmation)
        {
            await _travelerRepository.ReplaceOneAsync(travelerEntity);

            if (sendConfirmation)
            {
                var whatsappRequestModel = new WhatsappRequestModel
                {
                    Message = $"Seja Bem Vindo ao Hotel, Seu quarto é . Esperamos você no nosso café da manhã das 07 as 10. Wifi- Rede: Hotel - Senha: 12345678",
                    ReceiverNumber = travelerEntity.Telephone
                }; 
                await _whatsappService.Send(whatsappRequestModel);
            }

        }

    }
}
