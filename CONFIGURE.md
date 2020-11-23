# Configure a VPN and an OVPN File

## Disclaimer: You can use only UDP or TCP at a Time.

1. Set up a server loaded with the latest version of Ubuntu(prefered anny other Linux Distribution will suffice):   Use your favorite service to setup a server. Popular choices may include AWS, Azure etc. This will require a fee though some service providers do provide a free trial for some duration or limited network traffic. <b>Make sure that you note the IP address</b>

2. ssh into the server.

3. Run the following commands

```sh
curl -O https://raw.githubusercontent.com/angristan/openvpn-install/master/openvpn-install.sh
chmod +x openvpn-install.sh
./openvpn-install.sh
```

Now Fill Some Custom Settings Modules.

Defaults

```sh
Enable IPV6:        n
Port To Listen To:  1(Default)
Protocol:           1(UDP)(You can Use TCP/UDP according to your needs.)
DNS Resolver:       3(Cloud Fare)
Enable Compression: n
Encryption Settings:n
```

Now Enter the Names(of your choosing) for the Client
Enter Password For Client
Default: Enter No Password

4. Now save the .ovpn and .conf files created at the end of the process to your system. (You can Use WinSCP or Filezilla)

5. Open ports to accept TCP and UDP protocols.

```sh
iptables -A INPUT -i eth0 -m state --state NEW -p tcp --dport 1194 -j ACCEPT
iptables -t nat -A POSTROUTING -s <ip_address>/24 -o eth0 -j MASQUERADE
iptables -A OUTPUT -o tun+ -j ACCEPT
service openvpn@<.conf file name> restart
```

Disclaimer: If you are making multiple .conf files with names other than server.conf(default name). You might need to make some additional changes.

6. View iptables to check if eveything is working properly. You should be able to see the ports that you opened for UDP and TCP.

```sh
lsof -i:1194
```

## Further Information

[Documentation](https://github.com/angristan/openvpn-install)