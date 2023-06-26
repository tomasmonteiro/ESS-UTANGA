SET IDENTITY_INSERT identity_role_claim on 
GO
INSERT identity_role_claim(id,role_id, claim_type, claim_value)values(1,1,'AcessarCadastroPerfilUsuario', 'true')
GO
INSERT identity_role_claim(id,role_id, claim_type, claim_value)values(2,1,'IncluirAlterarPerfilUsuario', 'true')
GO
INSERT identity_role_claim(id,role_id, claim_type, claim_value)values(3,1,'AlterarPerfilUsuario', 'true')
GO
SET IDENTITY_INSERT identity_role_claim Off 

GO

SET IDENTITY_INSERT identity_role_claim on 
GO
INSERT identity_role_claim(id,role_id, claim_type, claim_value)values(4,1,'AcessarCadastroUsuario', 'true')
GO
INSERT identity_role_claim(id,role_id, claim_type, claim_value)values(5,1,'IncluirAlterarCadastroUsuario', 'true')
GO
INSERT identity_role_claim(id,role_id, claim_type, claim_value)values(6,1,'ExcluirCadastroUsuario', 'true')
GO
SET IDENTITY_INSERT identity_role_claim Off 
GO

SET IDENTITY_INSERT identity_role_claim on 
GO
 INSERT identity_role_claim(id,role_id, claim_type, claim_value)values(8,2,'IncluirAlterarCadastroUsuario', 'true')
GO
GO
SET IDENTITY_INSERT identity_role_claim Off 
GO

INSERT identity_role_claim(id,role_id, claim_type, claim_value)values(7,2,'AcessarCadastroUsuario', 'true')
GO
INSERT identity_role_claim(id,role_id, claim_type, claim_value)values(9,2,'ExcluirCadastroUsuario', 'true')






