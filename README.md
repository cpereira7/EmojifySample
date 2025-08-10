# EmojifySample

This sample demonstrates how to run the Emojify.NET project inside a Docker container with proper locale support for ONNX Runtime.

## About

Emojify.NET is a .NET library for emoji prediction using ONNX Runtime. It requires the `en_US.UTF-8` locale to be correctly configured in the container for its text normalization step.

## Problem

When running the sample inside a minimal Linux container (based on `mcr.microsoft.com/dotnet/runtime`), ONNX Runtime throws an error during model initialization:

```bash
Failed to construct locale with name: en_US.UTF-8: locale::facet::_S_create_c_locale name not valid
```

This happens because the required locale data is missing from the container.

### Solution

To fix this, the Docker image needs to install the `locales-all` package which provides all locale data including `en_US.UTF-8`.

#### Dockerfile snippet that works

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base

RUN apt-get update && apt-get install -y locales-all

USER $APP_UID
WORKDIR /app
```

This ensures ONNX Runtime’s string normalizer can successfully initialize the `en_US.UTF-8` locale.

## How to Build and Run

1. Build the Docker image:

```bash
docker build -t emojifysample .
```

2. Run the container:

```bash
docker run --rm emojifysample
```

### References

[Emojify.NET on Codeberg](https://codeberg.org/cpereira7/Emojify.NET) — The ONNX-based emoji predictor library used in this sample.
