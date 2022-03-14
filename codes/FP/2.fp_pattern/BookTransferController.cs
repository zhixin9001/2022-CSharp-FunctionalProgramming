using System.Text.RegularExpressions;
using LaYumba.Functional;
using Microsoft.AspNetCore.Mvc;
using static LaYumba.Functional.F;
using Unit = System.ValueTuple;

namespace FP._2.fp_pattern;

public class BookTransferController : ControllerBase

{
    private Regex bicRegex = new Regex("");
    private DateTime now;
    public IInstrumentService InstrumentService;

    Either<Error, Unit> Handle(BookTransfer cmd)
        => Validate(cmd)
            .Bind(ValidateBic)
            .Bind(Save);

    Either<Error, BookTransfer> Validate(BookTransfer cmd)
        => Right(cmd)
            .Bind(ValidateBic)
            .Bind(ValidateDate);

    Either<Error, Unit> Save(BookTransfer cmd) => null;


    Either<Error, BookTransfer> ValidateBic(BookTransfer cmd)
        => !bicRegex.IsMatch(cmd.Bic) ? Errors.InvalidBic : cmd;

    Either<Error, BookTransfer> ValidateDate(BookTransfer cmd)
        => cmd.Date.Date <= now.Date ? Errors.TransferDateIsPast : cmd;

    public IActionResult GetInstrumentDetails(string code)
        => InstrumentService.GetInstrumentDetails(code)
            .Match<IActionResult>(
                () => NotFound(),
                r => Ok(r));

    public IActionResult BookTransfer(BookTransfer request)
        => Handle(request)
            .Match<IActionResult>(
                Left: BadRequest,
                Right: _ => Ok());

    Validation<BookTransfer> ValidateDate1(BookTransfer cmd)
        => cmd.Date.Date <= now.Date ? Invalid(Errors.TransferDateIsPast) : Valid(cmd);

    Exceptional<Unit> Save1(BookTransfer transfer)
    {
        try
        {

        }
        catch (Exception e)
        {
            return e;
        }

        return Unit();
    }

    Validation<Exceptional<Unit>> Handle1(BookTransfer cmd)
        => ValidateDate1(cmd).Map(Save1);

}

public interface IInstrumentService
{
    Option<string> GetInstrumentDetails(string code);
}

public class BookTransfer
{
    public string Bic { get; set; }
    public DateTime Date { get; set; }
}