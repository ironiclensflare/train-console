# Train Console

[![Build Status](https://travis-ci.org/ironiclensflare/train-console.svg?branch=master)](https://travis-ci.org/ironiclensflare/train-console)

This is a simple console application to let you check when the next trains are for a given journey.

It is a major work in progress and more functionality will be added over time.

## Usage

You will need to [register and obtain an access token](http://realtime.nationalrail.co.uk/OpenLDBWSRegistration) for the OpenLDBWS API. Once you've done this set it as an environment variable called `LDBWS_TOKEN`

### Departures

To see a list of departures, simply run the app with two arguments - the [CRS codes](http://www.railwaycodes.org.uk/crs/CRS0.shtm) for the origin and destination stations.

```bash
trains bhm not
```

You can also use the `departing (dep)` command:

```bash
trains dep bhm not
```

### Arrivals

You can see a list of arrivals for the given station by using the `arriving (arr)` command:

```bash
trains arr not
```

If you're only interested in trains from a given origin, you can pass it as an optional second parameter:

```bash
trains arr not stp
```

## Compiling

The app is written in .NET Core 2.0 so you can either run it with `dotnet run` or compile it for your specific OS:

```bash
dotnet publish --self-contained -r osx.10.12-x64 -o /usr/local/bin/
```
