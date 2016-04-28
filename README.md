# RabbitMQHost

# To Run a Node

..\Rabbit.Host\bin\Debug>Rabbit.Host.exe nameofnode port

# To Cluster

(using rabbit cmd prompt Program Files (x86)\RabbitMQ Server\rabbitmq_server-3.5.4\sbin>)

rabbitmqctl -n nameofnode stop_app

rabbitmqctl -n nameofnode join_cluster othernode@local-host

rabbitmqctl -n nameofnode  start_app
