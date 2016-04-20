# RabbitMQExperiment
Run 3 nodes, update, load balance.


# To Run a Node

..\Rabbit.Host\bin\Debug>Rabbit.Host.exe <name of node> <port>

# To Cluster

(using rabbit cmd prompt Program Files (x86)\RabbitMQ Server\rabbitmq_server-3.5.4\sbin>)

rabbitmqctl -n <name of node> stop_app

rabbitmqctl -n <name of node> join_cluster <other node>@<local-host>

rabbitmqctl -n <name of node>  start_app

# To Do 
+ Update RabbitMQ
+ Load Balance Nodes
