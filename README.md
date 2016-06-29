# Captcha Generator - .NET
A simple class library used for generating image captcha with audio dynamically without the need for external database or library.  

Compatibility with `.Net 4.0 and above` versions.

## Introduction

This project is also available as a `nuget` package.  
Install the latest package by entering the following command in `Package Manager Console`

`Install-Package CaptchaGen`

Visit this [link](https://sample/gf) for previous versions

Alternatively you can clone this repo and build it yourself and refer this project in your main project.


## Usage

#### Captcha string Generation

Generate captcha strings using `CaptchaCodeFactory` class. For example, the following snippet generates captcha string with 8 character length.  Captcha string will contain alphanumeric characters generated with the help of `RNGCryptoServiceProvider` class to ensure randomness.

`String captchaCode = CaptchaCodeFactory.GenerateCaptchaCode(8)`

#### Image Generation

`ImageFactory` class generates the captcha image with the specified captcha string value. `ImageFactory.GenerateImage(string)` returns a `Stream` object that contains the image.

Following example snippet generates and serves the captcha image as an `HttpResponseMessage`

```
var imageStream = ImageFactory.GenerateImage(id);
imageStream.Position = 0;
HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
response.Content = new StreamContent(imageStream);
response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
return response;
```

#### Audio Generation

`AudioFactory` class generates the audio data for a specified captcha string value. It utilizes `SpeechSynthesizer` class to generate the audio data. `AudioFactory.GenerateAudio(string)` returns a `stream` object that contains the audio data

The following example generates and serves the audio as a response for an incoming request

```
HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
var audioStream = AudioFactory.GenerateAudio(id);
audioStream.Position = 0;
response.Content = new StreamContent(audioStream);
response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("audio/wav");
return response;
```

### Contribution

You are welcome to contribute to the project by adding new features and improving the existing ones. Fork the project and create a pull request with your features.

### License

[MIT license](https://en.wikipedia.org/wiki/MIT_License).