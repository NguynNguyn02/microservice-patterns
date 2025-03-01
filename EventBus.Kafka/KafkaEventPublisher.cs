﻿using Confluent.Kafka;
using EventBus.Abstractions;
using EventBus.Events;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace EventBus.Kafka;
public class KafkaEventPublisher(string topic, IProducer<string, string> producer, ILogger<KafkaEventPublisher> logger) : IEventPublisher
{
    public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IntegrationEvent
    {
        var json = JsonSerializer.Serialize(@event);
        logger.LogInformation("Publishing event to topic {topic}: {event}", topic, json);

        try
        {
            await producer.ProduceAsync(topic, new Message<string, string> { Key = @event.GetType().FullName!, Value = json });

            logger.LogInformation("Published event {@event}", @event.EventId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error publishing event {@event}", @event.EventId);
        }
    }
}
