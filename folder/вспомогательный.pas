var a,b:string;
      i:integer;
     FD:text;
begin
  assign(FD,'Chernovik.txt');
  reset(FD);
  i:=0;
  while not eof(FD) do 
    begin
      readln(FD,a);
      i:=i+1;
      write(a,', ');
    end;
  writeln();
  writeln();
  writeln(i);
end.     