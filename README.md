# componentsLab2
1st test checks if PasswordHasher.GetHash() returns anything;(passed)
2nd test checks if the hash is equal for two identical passwords encoded with the same salt;(passed)
3rd test checks if the hash is different for different passwords encoded with the same salt;(passed)
4th test checks if PasswordHasher.Init() changes salt and if the hash is different for two identical passwords encoded with the different salts;(passed)
