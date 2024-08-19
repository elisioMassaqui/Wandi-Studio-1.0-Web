import asyncio
import websockets
import random

async def send_messages(websocket, path):
    messages = ["Hello, Unity!", "Arduino", "Causa-Efeito", "SINER", "Mr.Robot"]
    try:
        while True:
            message = random.choice(messages)  # Escolhe uma mensagem aleatória
            await websocket.send(message)
            print(f'Enviando "{message}" pra Unity')
            await asyncio.sleep(1)  # Espera 1 segundo antes de enviar a próxima mensagem
    except Exception as e:
        print(f"Error: {e}")

async def main():
    async with websockets.serve(send_messages, "localhost", 8765):
        print('Servidor 8765 iniciado com sucesso...')
        await asyncio.Future()  # Run forever

asyncio.run(main())
