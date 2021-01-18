# Manually Create and Sign JWT with RSA 4096 private key

The article below explains how to Import and Export RSA Key Formats in .NET:

https://vcsjones.dev/key-formats-dotnet-3/

> One gotcha with openssl is to pay attention to the output of the key format. A common enough task from openssl is “Given this PEM-encoded RSA private key, give me a PEM encoded public-key” and is often enough done like this: openssl rsa -in key.pem -pubout Even if key.pem is a PKCS#1 RSAPrivateKey (“BEGIN RSA PRIVATE KEY”), the -pubout option will output a SPKI (“BEGIN PUBLIC KEY”), not an RSAPublicKey (“BEGIN RSA PUBLIC KEY”). For that, you would need to use -RSAPublicKey_out instead of -pubout. The openssl pkey commands will also typically give you PKCS#8 or SPKI formatted keys.

Often times RSA keys can be described as “PEM” encoded, but that is already ambiguous as to how the key is actually encoded. PEM takes the form of:
```
-----BEGIN LABEL-----
content
-----END LABEL-----
```
Private key in format PKCS#1:
```
-----BEGIN RSA PRIVATE KEY-----
MII...
-----END RSA PRIVATE KEY-----
```
Private key in format PKCS#8:
```
----BEGIN PRIVATE KEY------
...
---END PRIVATE KEY-----
```

> The base64-encoded text is an RSAPrivateKey from the PKCS#1 spec, which is just an ASN.1 SEQUENCE of integers that make up the RSA key. The corresponding .NET Core 3 API for this is `ImportRSAPrivateKey`, or one of its overloads. If your key is “PEM” encoded, you need to find the base64 text between the label BEGIN and END headers, base64 decode it, and pass to `ImportRSAPrivateKey`.

> Unencrypted PKCS#8 keys can be imported with `ImportPkcs8PrivateKey`, and encrypted PKCS#8 keys can be imported with `ImportEncryptedPkcs8PrivateKey`. Their usage is similar to `ImportRSAPrivateKey`.
