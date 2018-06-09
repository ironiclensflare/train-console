# Train Console
[![Build Status](https://travis-ci.org/ironiclensflare/train-console.svg?branch=master)](https://travis-ci.org/ironiclensflare/train-console)

This is a simple console application to let you check when the next trains are for a given journey.

It is a major work in progress and more functionality will be added over time.

## Usage

To use the app, simply run it with two arguments - the [CRS codes](http://www.railwaycodes.org.uk/crs/CRS0.shtm) for the origin and destination stations.

```bash
trains bhm not
```

## Compiling

The app is written in .NET Core 2.0 so you can either run it with `dotnet run` or compile it for your specific OS:

```bash
dotnet publish --self-contained -r osx.10.12-x64 -o /usr/local/bin/
```
