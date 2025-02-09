﻿using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddChatClient(new OllamaChatClient(new Uri("http://localhost:11434"), "llama3.1"));

var app = builder.Build();

var chatClient = app.Services.GetRequiredService<IChatClient>();

var chatCompletion = await chatClient.CompleteAsync("Quem é mais rápido o Superman ou o Flash?");

Console.WriteLine(chatCompletion.Message.Text);