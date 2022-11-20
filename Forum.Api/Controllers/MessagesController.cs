using Forum.Bll.Interfaces;
using Forum.Common.Dtos.Category;
using Forum.Common.Dtos.Message;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/messages")]
    public class MessagesController : ApplicationControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IList<MessageDto>> GetMessages()
        {
            var messages = await _messageService.GetMessagesAsync();

            return messages;
        }

        [HttpGet("{id}")]
        public async Task<MessageDto> GetMessage(int id)
        {
            var message = await _messageService.GetMessageByIdAsync(id);

            return message;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] MessageUpdateDto messageUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var message = await _messageService.CreateMessageAsync(messageUpdateDto);

            return CreatedAtAction(nameof(GetMessage), new { id = message.Id }, message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessage(int id, [FromBody] MessageUpdateDto messageUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _messageService.UpdateMessageAsync(id, messageUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _messageService.DeleteMessageAsync(id);

            return NoContent();
        }
    }
}
