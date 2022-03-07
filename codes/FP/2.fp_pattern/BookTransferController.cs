using LaYumba.Functional;
using Unit = System.ValueTuple;

namespace FP._2.fp_pattern;

public class BookTransferController
{
    Either<Error, Unit> Handle(BookTransfer cmd);

    Either<Error, BookTransfer> Validate(BookTransfer cmd);
}

public class BookTransfer
{
}