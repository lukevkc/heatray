<br/>
<div align="center">
  <a href="https://github.com/lukevkc/heatray">
    <img src="heatray-logo-no-background.png" alt="Logo" height="200">
  </a>

  <h3 align="center">heatray</h3>

  <p align="center">
    Simple and deadly efficient processor and client for gathering logs from your applications. Built-in .NET integration.
    <br/>
    <br/>
    <a href="https://github.com/lukevkc/heatray"><strong>Explore the docs »</strong></a>
    <br/>
    <br/>
  </p>

![Issues](https://img.shields.io/github/issues/lukevkc/heatray)
[![NuGet Package](https://img.shields.io/badge/.NET%20-8.0-blue.svg)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
</div>

## Table Of Contents

* [About the Project](#about-the-project)
* [Built With](#built-with)
* [Usage](#usage)

## About The Project

Project aims to address the vital need for efficient log processing in application environments. The application serve as a robust log processor, where client applications will send logs for processing and storage. Users will have easy access to aggregated logs for analysis and monitoring purposes.
<br>
To meet this new challenge, we propose a solution that includes a client plugin integrated into existing .NET applications and a lightweight, high-performance server-side application. The client plugin seamlessly sends logs to the server application using gRPC protocol, ensuring efficient communication.
<br>
The server application, deployed on any suitable server, is optimized to handle large volumes of log data with minimal system overhead. It stores log entries in its database and processes them, enriching them with comprehensive metadata gathered during log processing.
<br>
This application is designed to operate within distributed systems, providing the flexibility to run on any machine within the network. This capability facilitates seamless integration into existing infrastructure setups, regardless of their complexity or geographical distribution.
<br>
By adopting this solution, businesses can effectively process and store logs from their applications, enabling efficient analysis and troubleshooting. Our system offers scalability, performance, and reliability, ensuring that critical log data is processed and stored promptly and efficiently.

## Built With

.NET

## Usage

_For more examples, please refer to the [Documentation](https://github.com/lukevkc/heatray)_

## Todo

Server service
Library
Client API/Frontend
more..
and more
