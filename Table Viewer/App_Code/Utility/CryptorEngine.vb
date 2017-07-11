Imports System.Security.Cryptography
Imports System.Text

Public Class CryptorEngine
    Public Shared Function Encrypt(toEncrypt As String, useHashing As Boolean) As String
        Dim keyArray As Byte()
        Dim toEncryptArray As Byte() = UTF8Encoding.UTF8.GetBytes(toEncrypt)

        Dim key As String = My.Settings.EncryptionKey '16 bytes = 128 bits

        'If hashing use get hashcode regards to your key
        If useHashing Then
            Dim hashmd5 As New MD5CryptoServiceProvider()
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key))
            'Always release the resources and flush data of the Cryptographic service provide. Best Practice
            hashmd5.Clear()
        Else
            keyArray = UTF8Encoding.UTF8.GetBytes(key)
        End If

        Dim tdes As New TripleDESCryptoServiceProvider()
        'set the secret key for the tripleDES algorithm
        tdes.Key = keyArray
        'mode of operation. there are other 4 modes.
        'We choose ECB(Electronic code Book)
        tdes.Mode = CipherMode.ECB
        'padding mode(if any extra byte added)

        tdes.Padding = PaddingMode.PKCS7

        Dim cTransform As ICryptoTransform = tdes.CreateEncryptor()
        'transform the specified region of bytes array to resultArray
        Dim resultArray As Byte() = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
        'Release resources held by TripleDes Encryptor
        tdes.Clear()
        'Return the encrypted data into unreadable string format
        Return Convert.ToBase64String(resultArray, 0, resultArray.Length)
    End Function

    Public Shared Function Decrypt(cipherString As String, useHashing As Boolean) As String
        Dim keyArray As Byte() 'get the byte code of the string

        Dim toEncryptArray As Byte() = Convert.FromBase64String(cipherString)

        Dim key As String = My.Settings.EncryptionKey '16 bytes = 128 bits

        If useHashing Then
            'if hashing was used get the hash code with regards to your key
            Dim hashmd5 As New MD5CryptoServiceProvider()
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key))
            'release any resource held by the MD5CryptoServiceProvider
            hashmd5.Clear()
        Else
            'if hashing was not implemented get the byte code of the key
            keyArray = UTF8Encoding.UTF8.GetBytes(key)
        End If

        Dim tdes As New TripleDESCryptoServiceProvider()
        'set the secret key for the tripleDES algorithm
        tdes.Key = keyArray
        'mode of operation. there are other 4 modes. 
        'We choose ECB(Electronic code Book)

        tdes.Mode = CipherMode.ECB
        'padding mode(if any extra byte added)
        tdes.Padding = PaddingMode.PKCS7

        Dim cTransform As ICryptoTransform = tdes.CreateDecryptor()
        Dim resultArray As Byte() = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
        'Release resources held by TripleDes Encryptor                
        tdes.Clear()
        'return the Clear decrypted TEXT
        Return UTF8Encoding.UTF8.GetString(resultArray)
    End Function

End Class
