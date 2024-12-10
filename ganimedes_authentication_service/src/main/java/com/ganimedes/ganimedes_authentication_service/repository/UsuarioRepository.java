package com.ganimedes.ganimedes_authentication_service.repository;

import com.ganimedes.ganimedes_authentication_service.model.Login;
import com.ganimedes.ganimedes_authentication_service.model.Usuario;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public interface UsuarioRepository extends JpaRepository<Usuario, String> {

    @Query(value = "SELECT * FROM ganimedes.usuario u where u.email = :email and u.password = :password", nativeQuery = true)
    Optional<Usuario> findByEmailAndPassword(@Param("email") String email, @Param("password") String password);

}