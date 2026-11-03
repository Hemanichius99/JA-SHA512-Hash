.code
; Przykładowy kod, taki o zeby sprawdzic czy dziala.
Hash PROC
    lea eax, [rcx + rdx]    ; arg1 = ECX, arg2 = EDX, wynik w EAX
    ret
Hash ENDP

END